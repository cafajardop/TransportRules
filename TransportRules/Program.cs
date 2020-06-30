using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using OpheliaSuiteV2.Core.DataAccess.MongoDb;
using System.Text.Encodings;
using System.Text;


namespace TransportRules
{
    class Program
    {
        UTF8Encoding utf8 = new UTF8Encoding();
        //AMBIENTE ORIGEN
        static DbContext contextSource = new GenericDbContext(new DbClient(ConfigurationManager.ConnectionStrings["DbContext"].ToString()), ConfigurationManager.AppSettings["DataBase"].ToString());
        static GenericRepository<Entity> EntitySourceRepo = new GenericRepository<Entity>(contextSource);
        static GenericRepository<Rule> RuleSourceRepo = new GenericRepository<Rule>(contextSource);
        static GenericRepository<Function> FuncSourceRepo = new GenericRepository<Function>(contextSource);
        //AMBIENTE DESTINO
        //FIDUPRUEBAS
        //static DbContext contextTarget = new GenericDbContext(new DbClient("mongodb://10.70.1.11:27017"), "BRM_V2");
        //OCGN
        static DbContext contextTarget = new GenericDbContext(new DbClient("mongodb://10.1.0.162:27017"), "BRM_V2");
        static GenericRepository<Entity> EntityTargetRepo = new GenericRepository<Entity>(contextTarget);
        static GenericRepository<Rule> RuleTargetRepo = new GenericRepository<Rule>(contextTarget);
        static GenericRepository<Function> FuncTargetRepo = new GenericRepository<Function>(contextTarget);

        static List<Entity> Entities = new List<Entity>();
        static List<Rule> Rules = new List<Rule>();
        static List<Function> Functions = new List<Function>();

        const string ARCHIVO_REGLAS = @"C:\Users\carlosf\Desktop\archivo\Reglas.csv";
        const string ARCHIVO_MSJNUEVOS = @"C:\Users\carlosf\Desktop\archivo\Nuevo.txt";
        const string docPath = @"C:\Users\carlosf\Desktop\archivo\Mensajes.csv";


        static Dictionary<string, string> dictVariables = null;
        static List<string> ListReglas = new List<string>();
        static List<string[]> ListReglas2 = new List<string[]>();
        static StringBuilder infoFileGlobal = new StringBuilder();

        static void Main(string[] args)
        {
            //var rule = RuleSourceRepo.List(r => r.Code == "RUL_RD0247ValidateAll").FirstOrDefault();
            //var rule = RuleSourceRepo.List(r => r.Code == "RUL_CACODETNIC").FirstOrDefault();

            if (args.Length == 0)
            {

            }
            List<string> info = ReadInfoTemporaly();


            bool updateEntityTrue = false;
            bool updateRulesMessages = false;
            bool upddat = false;

            //Actualizar los mensajes de una entidad en BRM_V2 Expresiones regulares
            if (updateEntityTrue)
            {
                var UpdateEntity = EntitySourceRepo.FindBy(new Filter<Entity>().AndIn("Code", "ENT_StructureRes0247")).FirstOrDefault();
                int index = 1;
                for (int i = 0; i < UpdateEntity.Properties.Count; i++)
                {

                    foreach (var item1 in UpdateEntity.Properties[i].Attributes)
                    {
                        string[] actual = info[i].Split(";");
                        string[] variablesActualizar = actual[3].Split("-");
                        string messageComplete = actual[3].Replace("\"", "");

                        string variableActualizar = variablesActualizar[0].Replace("\"", "");
                        string expresionActualizar = actual[2];
                        string EsActiva = actual[4];

                        string[] variables = item1.Message?.Split("-");
                        string reguex = item1.Value;
                        string message = item1.Message;

                        if (EsActiva != "0" && reguex!= null && message != null)
                        {
                            //Expresion regular
                            item1.Value = item1.Value?.Replace($"{reguex}", $"{expresionActualizar}");
                            //Mensajes
                            item1.Message = item1.Message?.Replace($"{message}", $"{messageComplete}");
                        }
                    }
                }
                EntitySourceRepo.Update(UpdateEntity);
                return;
            }
            
            var rule = RuleSourceRepo.List(r => r.Code == "RUL_RD0247ValidateAll").FirstOrDefault();
            if (updateRulesMessages)

            {
                //if (rule != null)
                //{
                // GetRuleRules(rule);
                ChangeMessage();
                //}
            }

            if(upddat)
            {
                updt();
            }

            if (rule != null)
            {
                //Obtenemos todas las entidades de forma recursiva
                GetRuleEntities(rule);
                //Obtenemos todas las funciones dependientes
                GetRuleFunctions(rule);
                //Obtenemos todas las reglas dependientes
                GetRuleRules(rule);
            }

            //Validamos que las entidades no existan para insertarlas sin problema
            if (Entities.Count > 0)
            {
                var entExists = EntityTargetRepo.FindBy(new Filter<Entity>().AndIn("Code", Entities.Select(e => e.Code).ToArray())).ToList();
                if (entExists.Count > 0)
                {
                    foreach (Entity f in entExists)
                    {
                        EntityTargetRepo.Delete(f);
                    }
                }
                //throw new Exception($"Las siguientes entidades ya existen en el destino: {string.Join(", ", entExists.Select(e => e.Code))}");
            }

            if (Functions.Count > 0)
            {
                var funcExists = FuncTargetRepo.FindBy(new Filter<Function>().AndIn("Code", Functions.Select(e => e.Code).ToArray())).ToList();
                if (funcExists.Count > 0)
                {
                    foreach (Function f in funcExists)
                    {
                        FuncTargetRepo.Delete(f);
                    }
                    //throw new Exception($"Las siguientes funciones ya existen en el destino: {string.Join(", ", funcExists.Select(e => e.Code))}");
                }
            }

            if (Rules.Count > 0)
            {
                var ruleExists = RuleTargetRepo.FindBy(new Filter<Rule>().AndIn("Code", Rules.Select(e => e.Code).ToArray())).ToList();
                if (ruleExists.Count > 0)
                {
                    foreach (Rule r in ruleExists)
                    {
                        RuleTargetRepo.Delete(r);
                    }
                    //throw new Exception($"Las siguientes reglas ya existen en el destino: {string.Join(", ", ruleExists.Select(e => e.Code))}");
                }
            }

            var ruleExist = RuleTargetRepo.List(e => e.Code == rule.Code).ToList();
            if (ruleExist.Count > 0)
            {
                RuleTargetRepo.Delete(rule);
                //throw new Exception($"Las siguientes reglas ya existen en el destino: {string.Join(", ", ruleExist.Select(e => e.Code))}");
            }

            //Insertamos las entidades
            foreach (Entity ent in Entities)
            {
                //Generamos nuevos ids
                ent.Id = EntityBase.NewId();
                EntityTargetRepo.Add(ent);
            }
            //Insertamos las funciones
            foreach (Function ent in Functions)
            {
                //Generamos nuevos ids
                ent.Id = EntityBase.NewId();
                FuncTargetRepo.Add(ent);
            }
            //Insertamos las reglas
            foreach (Rule ent in Rules)
            {
                //Generamos nuevos ids
                ent.Id = EntityBase.NewId();
                RuleTargetRepo.Add(ent);
            }

            rule.Id = EntityBase.NewId();
            RuleTargetRepo.Add(rule);

            Console.WriteLine("Transporte finalizado!");
            Console.ReadLine();
        }

        #region ContextSource

        public static void ChangeMessage()
        {
            ListReglas = File.ReadLines(ARCHIVO_REGLAS, System.Text.Encoding.UTF7).Select(line => line).ToList();

            foreach (var item in ListReglas)
            {
                var ruleExists = RuleSourceRepo.FindBy(new Filter<Rule>().AndIn("Code", item.Trim().ToUpper())).FirstOrDefault();

                List<string> valuesNotFound = new List<string>();

                if (ruleExists != null)
                {
                    if (ruleExists.ReferenceRule.Count > 0)
                    {
                        var ruleExists2 = RuleSourceRepo.FindBy(new Filter<Rule>().AndIn("Code", ruleExists.ReferenceRule[0].Trim().ToUpper())).FirstOrDefault();

                        if (ruleExists2.ReferenceFunction.Count > 0)
                        {
                            var functExists = FuncTargetRepo.FindBy(new Filter<Function>().AndIn("Code", ruleExists2.ReferenceFunction[0].Trim().ToUpper())).FirstOrDefault();
                            if (functExists != null)
                            {

                                if (functExists.SourceCode.Length > 0)
                                {


                                    //StringBuilder infoFile2 = new StringBuilder();
                                    infoFileGlobal.AppendLine($"{item};{ruleExists2.Code}_{functExists.Code}_{functExists.SourceCode}");

                                    //File.AppendAllText(docPath, infoFile.ToString(), UTF8Encoding.UTF8);
                                }
                            }

                        }

                    }

                    if (ruleExists.ValidValuesVariables != null || ruleExists.ValidValuesVariables.Count > 0)
                    {
                        foreach (var valid in ruleExists.ValidValuesVariables)
                        {
                            if (!string.IsNullOrEmpty(valid.NonValidMessage))
                            {
                                StringBuilder infoFile = new StringBuilder();
                                infoFile.AppendLine($"{item};{valid.Code};{valid.NonValidMessage}");
                                if (infoFileGlobal.Length > 0)
                                {
                                    infoFile.AppendLine(infoFileGlobal.ToString());
                                }

                                File.AppendAllText(docPath, infoFile.ToString(), UTF8Encoding.UTF8);
                            }
                        }
                        //RuleSourceRepo.Update(ruleExists);
                    }
                }
                else
                {
                    string ninguno = "No encontro";
                    Console.WriteLine(ninguno);
                }
            }
        }


        private static void updt()
        {
            ListReglas = File.ReadLines(ARCHIVO_REGLAS, System.Text.Encoding.UTF7).Select(line => line).ToList();
            ListReglas2 = File.ReadLines(ARCHIVO_MSJNUEVOS, System.Text.Encoding.UTF8).Select(line => line.Split("\t")).ToList();

            foreach (var item in ListReglas)
            {
                var ruleExists = RuleSourceRepo.FindBy(new Filter<Rule>().AndIn("Code", item.Trim().ToUpper())).FirstOrDefault();

                List<string> valuesNotFound = new List<string>();

                if (ruleExists != null)
                {
                    var lstMensajesRegla = ListReglas2.Where(z => z[0] == item).ToList();

                    if (ruleExists.ValidValuesVariables != null || ruleExists.ValidValuesVariables.Count > 0)
                    {
                        foreach (var valid in ruleExists.ValidValuesVariables)
                        {
                            string mensajeRegla = lstMensajesRegla.Where(m => m[1] == valid.Code).Select(c=> c[2].ToString()).FirstOrDefault();

                            if (!string.IsNullOrEmpty(valid.NonValidMessage) && !string.IsNullOrEmpty(mensajeRegla))
                            {
                                
                                valid.NonValidMessage = valid.NonValidMessage.Replace($"{valid.NonValidMessage}", $"{mensajeRegla}");
                            }
                        }
                        RuleSourceRepo.Update(ruleExists);
                    }
                }
                else
                {
                    string ninguno = "No encontro";
                    Console.WriteLine(ninguno);
                }



            }


        }


        private static string ReplaceAccent(string accent)
        {
            return accent.Replace("Á", "A").Replace("É", "E").Replace("Í", "I").Replace("Ó", "O").Replace("Ú", "U");
        }
        private static List<string> ReadInfoTemporaly()
        {
            List<string> infofile = new List<string>();
            using (StreamReader sr = new StreamReader(@"C:\Users\carlosf\Documents\Backup_Carlos_27042020\Requerimientos\Resoluciones\0247\CargueExpresionesRegulares\PlantillaCargueExpresiones.txt", System.Text.Encoding.UTF8))
                                                        
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    infofile.Add(line.Replace("�", " "));
                }
            }
            return infofile;
        }


        public static void GetRuleFunctions(Rule rule)
        {
            List<string> listFunc = new List<string>();
            if (rule.ReferenceFunction != null)
                listFunc.AddRange(rule.ReferenceFunction);

            if (listFunc.Count == 0)
                return;

            foreach (string codeFunc in listFunc)
            {
                if (Functions.Exists(f => f.Code == codeFunc))
                    continue;
                Function func = FuncSourceRepo.List(e => e.Code == codeFunc).FirstOrDefault();
                if (func == null)
                    throw new Exception($"La función {codeFunc} esta referenciada en la regla {rule.Code} pero no existe");
                GetFuncEntities(func);
                GetFuncFunctions(func);
                Functions.Add(func);
            }
        }
        public static void GetRuleRules(Rule rule)
        {
            if (rule.ReferenceRule == null || rule.ReferenceRule.Count == 0)
                return;
            foreach (string codeFunc in rule.ReferenceRule)
            {
                if (Rules.Exists(f => f.Code == codeFunc))
                    continue;
                Rule rul = RuleSourceRepo.List(e => e.Code == codeFunc).FirstOrDefault();
                if (rul == null)
                    throw new Exception($"La regla {codeFunc} esta referenciada en la regla {rule.Code} pero no existe");
                GetRuleEntities(rul);
                GetRuleFunctions(rul);
                GetRuleRules(rul);
                Rules.Add(rul);
            }
        }
        public static void GetRuleEntities(Rule rule)
        {
            if (rule.ReferenceEntities == null || rule.ReferenceEntities.Count == 0)
                return;
            foreach (string codeEntity in rule.ReferenceEntities)
            {
                if (Entities.Exists(f => f.Code == codeEntity))
                    continue;
                Entity entity = EntitySourceRepo.List(e => e.Code == codeEntity).FirstOrDefault();
                if (entity == null)
                    throw new Exception($"La entidad {codeEntity} esta referenciada en la regla {rule.Code} pero no existe");
                GetEntityEntities(entity);
                Entities.Add(entity);
            }
        }
        public static void GetFuncFunctions(Function func)
        {
            List<string> listFunc = new List<string>();
            if (func.ReferenceFunction != null)
                listFunc.AddRange(func.ReferenceFunction);
            listFunc.AddRange(func.ReferenceSysFunction);
            if (listFunc.Count == 0)
                return;

            foreach (string codeFunc in listFunc)
            {
                if (Functions.Exists(f => f.Code == codeFunc))
                    continue;
                Function function = FuncSourceRepo.List(e => e.Code == codeFunc).FirstOrDefault();
                if (function == null)
                    throw new Exception($"La función {codeFunc} esta referenciada en la función {func.Code} pero no existe");
                GetFuncFunctions(function);
                Functions.Add(function);
            }
        }
        public static void GetFuncEntities(Function func)
        {
            if (func.ReferenceEntities == null || func.ReferenceEntities.Count == 0)
                return;
            foreach (string codeEntity in func.ReferenceEntities)
            {
                if (Entities.Exists(f => f.Code == codeEntity))
                    continue;
                Entity entity = EntitySourceRepo.List(e => e.Code == codeEntity).FirstOrDefault();
                if (entity == null)
                    throw new Exception($"La entidad {codeEntity} esta referenciada en la función {func.Code} pero no existe");
                GetEntityEntities(entity);
                Entities.Add(entity);
            }
        }
        public static void GetEntityEntities(Entity entity)
        {
            if (entity.ReferenceEntities == null || entity.ReferenceEntities.Count == 0)
                return;
            foreach (string codeEntity in entity.ReferenceEntities)
            {
                if (Entities.Exists(f => f.Code == codeEntity))
                    continue;
                Entity ent = EntitySourceRepo.List(e => e.Code == codeEntity).FirstOrDefault();
                if (ent == null)
                    throw new Exception($"La entidad {codeEntity} esta referenciada en la entidad {entity.Code} pero no existe");
                GetEntityEntities(ent);
                Entities.Add(ent);
            }
        }

        #endregion

        #region ContextTarget



        #endregion
    }
}