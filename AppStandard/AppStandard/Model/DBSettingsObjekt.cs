﻿using System;
using System.Collections.Generic;
using System.Text;
using Realms;


namespace AppStandard.Model
{
    /// <summary>
    /// DBS ettings objekt.
    /// </summary>
    public class DBSettingsObjekt : RealmObject
    {

        public string Key { get; set; }
        public string Value { get; set; }

        public DBSettingsObjekt()
        {

        }
    }
}
