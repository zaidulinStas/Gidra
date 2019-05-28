using System;
using System.Collections.Generic;
using System.Windows.Controls;
using GidraSIM.Core.Model;
using GidraSIM.GUI.Core.BlocksWPF;

namespace GidraSIM.GUI.Utility
{
    public class ViewModelConverter : IViewModelConverter
    {
        public ViewModelConverter()
        {

        }

        public void Map(UIElementCollection uIElementCollection, SimulationOptions simOptions)
        {
            Dictionary<ProcedureWPF, Procedure> procedures = new Dictionary<ProcedureWPF, Procedure>();
            Dictionary<ResourceWPF, Resource> resources = new Dictionary<ResourceWPF, Resource>();

            var resultProcedures = new List<Procedure>();

            foreach (var element in uIElementCollection)
            {
                //смотрим все соединения процедур
                if (element is ProcConnectionWPF)
                {
                    var connection = (element as ProcConnectionWPF);

                    //TODO типа можно здесь всё обработать
                    // Комментарий от 28.05.19: facepalm
                    if (connection.StartBlock is StartBlockWPF && connection.EndBlock is EndBlockWPF)
                    {
                        throw new Exception("Нельзя просто соединить начало с концом!");
                    }

                    //обработка стартового блока
                    if (connection.StartBlock is StartBlockWPF)
                    {
                        Procedure block;

                        //если в первый раз встерчаем блок
                        if (!(procedures.ContainsKey(connection.EndBlock as ProcedureWPF)))
                        {
                            //первого нет, второй значимый
                            block = (connection.EndBlock as ProcedureWPF).BlockModel;

                            //добавляем его в список
                            procedures.Add(connection.EndBlock as ProcedureWPF, block);

                            //добавляем его в список всех блоков процесса
                            resultProcedures.Add(block);
                        }
                        //иначе просто берём из базы
                        else
                            block = procedures[connection.EndBlock as ProcedureWPF];

                        //process.StartBlock = block;
                        //соединение будет когда-то потом
                    }
                    //обработка конечного блока
                    else if (connection.EndBlock is EndBlockWPF)
                    {
                        Procedure block = null;

                        //если в первый раз такое встречаем
                        if (!(procedures.ContainsKey(connection.StartBlock as ProcedureWPF)))
                        {
                            block = (connection.StartBlock as ProcedureWPF).BlockModel;
                            procedures.Add(connection.StartBlock as ProcedureWPF, block);
                            resultProcedures.Add(block);
                        }
                        else
                        {
                            block = procedures[connection.StartBlock as ProcedureWPF];
                        }
                        //process.EndBlock = block;
                        //соединение будет когда-то потом
                    }
                    //обработка всех остальных блоков
                    else
                    {
                        Procedure block = null;

                        //если в первый раз такое встречаем
                        if (!(procedures.ContainsKey(connection.StartBlock as ProcedureWPF)))
                        {
                            block = (connection.StartBlock as ProcedureWPF).BlockModel;
                            procedures.Add(connection.StartBlock as ProcedureWPF, block);
                            resultProcedures.Add(block);
                        }
                        //если в первый раз такое встречаем
                        if (!(procedures.ContainsKey(connection.EndBlock as ProcedureWPF)))
                        {
                            block = (connection.EndBlock as ProcedureWPF).BlockModel;
                            procedures.Add(connection.EndBlock as ProcedureWPF, block);
                            resultProcedures.Add(block);
                        }


                        //к счастью там только один вход и выход
                        //process.Connections.Connect(procedures[connection.StartBlock as ProcedureWPF], connection.StartPort,
                        //    procedures[connection.EndBlock as ProcedureWPF], connection.EndPort);

                    }
                }
                //сотрим соединения ресурсов
                else if (element is ResConnectionWPF)
                {

                    var connection = (element as ResConnectionWPF);
                    ProcedureWPF procedure;
                    ResourceWPF resourceWPF;
                    if (connection.StartBlock is ProcedureWPF)
                    {
                        procedure = connection.StartBlock as ProcedureWPF;
                        resourceWPF = connection.EndBlock as ResourceWPF;
                    }
                    else
                    {
                        procedure = connection.EndBlock as ProcedureWPF;
                        resourceWPF = connection.StartBlock as ResourceWPF;
                    }
                    Procedure block = null;

                    //если в первый раз такое встречаем
                    if (!(procedures.ContainsKey(procedure)))
                    {
                        block = procedure.BlockModel;
                        procedures.Add(procedure, block);
                        resultProcedures.Add(block);
                    }
                    else
                        block = procedures[procedure];

                    Resource resource = null; ;
                    //если в первый раз такое встречаем
                    if (!(resources.ContainsKey(resourceWPF)))
                    {
                        resource = this.ConvertWpfResourceToModel(resourceWPF);
                        resources.Add(resourceWPF, resource);
                        //process.Resources.Add(resource); // WTF???
                    }
                    else
                        resource = resources[resourceWPF];

                    if (block is Procedure)
                        (block as Procedure).Resources.Add(resource);
                    else
                        throw new ArgumentException("Ресурсы поддерживает только блоки типа Procedure");
                }
            }

            simOptions.Procedures = resultProcedures;
        }

        private Resource ConvertWpfResourceToModel(ResourceWPF resourceWPF)
        {
            if (resourceWPF == null)
                throw new ArgumentNullException();
            return (resourceWPF as ResourceWPF).ResourceModel;
        }
    }
}
