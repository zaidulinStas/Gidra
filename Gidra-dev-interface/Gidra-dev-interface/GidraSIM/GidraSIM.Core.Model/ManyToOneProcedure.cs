﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GidraSIM.Core.Model
{
    /// <summary>
    /// Общий класс процедура, выполняющей часть процесса проектировани
    /// </summary>
    public class ManyToOneProcedure : Procedure
    {
        /// <summary>
        /// Ресурсы процедуры, включая все вложенные
        /// </summary>
        public override IList<Resource> AllResources => Resources;

        /// <summary>
        /// Функция, вызывающаяся при начале моделирования 
        /// </summary>
        protected override bool OnStartModeling()
        {
            if (!Resources.All(x => x.IsFree))
            {
                return false;
            }

            foreach (var resource in Resources)
            {
                resource.Use();
            }

            return true;
        }

        /// <summary>
        /// Обновление моделирования процедуры
        /// </summary>
        protected override bool OnUpdateModeling(double curTime)
        {
            return true;
        }

        /// <summary>
        /// Функция, вызывающаяся при окончании моделирования 
        /// </summary>
        protected override bool OnEndModeling()
        {
            //Inputs[0].Tokens.Peek().Quality = MaxQuality;

            _targetQuality = MaxQuality;

            foreach (var resource in Resources)
            {
                resource.Release();
            }

            return true;
        }
    }
}
