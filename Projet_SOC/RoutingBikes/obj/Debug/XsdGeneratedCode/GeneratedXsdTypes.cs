//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RoutingBikes.ContractTypes
{
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("MSBuild", "17.0.0+c9eb9dd64e9a2e8a433900a1a626d65a2bce4428")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/ProxyCacheServer")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://schemas.datacontract.org/2004/07/ProxyCacheServer", IsNullable=true)]
    public partial class JCDecauxItem
    {
        
        private Station[] itemField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable=true)]
        public Station[] item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("MSBuild", "17.0.0+c9eb9dd64e9a2e8a433900a1a626d65a2bce4428")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/ProxyCacheServer")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://schemas.datacontract.org/2004/07/ProxyCacheServer", IsNullable=true)]
    public partial class Station
    {
        
        private int available_bike_standsField;
        
        private bool available_bike_standsFieldSpecified;
        
        private int available_bikesField;
        
        private bool available_bikesFieldSpecified;
        
        private int bike_standsField;
        
        private bool bike_standsFieldSpecified;
        
        private string contract_nameField;
        
        private string nameField;
        
        private int numberField;
        
        private bool numberFieldSpecified;
        
        private Position positionField;
        
        /// <remarks/>
        public int available_bike_stands
        {
            get
            {
                return this.available_bike_standsField;
            }
            set
            {
                this.available_bike_standsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool available_bike_standsSpecified
        {
            get
            {
                return this.available_bike_standsFieldSpecified;
            }
            set
            {
                this.available_bike_standsFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public int available_bikes
        {
            get
            {
                return this.available_bikesField;
            }
            set
            {
                this.available_bikesField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool available_bikesSpecified
        {
            get
            {
                return this.available_bikesFieldSpecified;
            }
            set
            {
                this.available_bikesFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public int bike_stands
        {
            get
            {
                return this.bike_standsField;
            }
            set
            {
                this.bike_standsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool bike_standsSpecified
        {
            get
            {
                return this.bike_standsFieldSpecified;
            }
            set
            {
                this.bike_standsFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string contract_name
        {
            get
            {
                return this.contract_nameField;
            }
            set
            {
                this.contract_nameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        public int number
        {
            get
            {
                return this.numberField;
            }
            set
            {
                this.numberField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool numberSpecified
        {
            get
            {
                return this.numberFieldSpecified;
            }
            set
            {
                this.numberFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public Position position
        {
            get
            {
                return this.positionField;
            }
            set
            {
                this.positionField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("MSBuild", "17.0.0+c9eb9dd64e9a2e8a433900a1a626d65a2bce4428")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/ProxyCacheServer")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://schemas.datacontract.org/2004/07/ProxyCacheServer", IsNullable=true)]
    public partial class Position
    {
        
        private double latField;
        
        private bool latFieldSpecified;
        
        private double lngField;
        
        private bool lngFieldSpecified;
        
        /// <remarks/>
        public double lat
        {
            get
            {
                return this.latField;
            }
            set
            {
                this.latField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool latSpecified
        {
            get
            {
                return this.latFieldSpecified;
            }
            set
            {
                this.latFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public double lng
        {
            get
            {
                return this.lngField;
            }
            set
            {
                this.lngField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool lngSpecified
        {
            get
            {
                return this.lngFieldSpecified;
            }
            set
            {
                this.lngFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("MSBuild", "17.0.0+c9eb9dd64e9a2e8a433900a1a626d65a2bce4428")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/ProxyCacheServer")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://schemas.datacontract.org/2004/07/ProxyCacheServer", IsNullable=true)]
    public partial class ArrayOfStation
    {
        
        private Station[] stationField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Station", IsNullable=true)]
        public Station[] Station
        {
            get
            {
                return this.stationField;
            }
            set
            {
                this.stationField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("MSBuild", "17.0.0+c9eb9dd64e9a2e8a433900a1a626d65a2bce4428")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/", IsNullable=false)]
    public partial class GetDataFromCache
    {
        
        private string cacheItemNameField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string CacheItemName
        {
            get
            {
                return this.cacheItemNameField;
            }
            set
            {
                this.cacheItemNameField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("MSBuild", "17.0.0+c9eb9dd64e9a2e8a433900a1a626d65a2bce4428")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/", IsNullable=false)]
    public partial class GetDataFromCacheResponse
    {
        
        private JCDecauxItem getDataFromCacheResultField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public JCDecauxItem GetDataFromCacheResult
        {
            get
            {
                return this.getDataFromCacheResultField;
            }
            set
            {
                this.getDataFromCacheResultField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("MSBuild", "17.0.0+c9eb9dd64e9a2e8a433900a1a626d65a2bce4428")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/", IsNullable=false)]
    public partial class GetAllStation
    {
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("MSBuild", "17.0.0+c9eb9dd64e9a2e8a433900a1a626d65a2bce4428")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/", IsNullable=false)]
    public partial class GetAllStationResponse
    {
        
        private JCDecauxItem getAllStationResultField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public JCDecauxItem GetAllStationResult
        {
            get
            {
                return this.getAllStationResultField;
            }
            set
            {
                this.getAllStationResultField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("MSBuild", "17.0.0+c9eb9dd64e9a2e8a433900a1a626d65a2bce4428")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/", IsNullable=false)]
    public partial class GetOneContract
    {
        
        private string cacheItemNameField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string CacheItemName
        {
            get
            {
                return this.cacheItemNameField;
            }
            set
            {
                this.cacheItemNameField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("MSBuild", "17.0.0+c9eb9dd64e9a2e8a433900a1a626d65a2bce4428")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/", IsNullable=false)]
    public partial class GetOneContractResponse
    {
        
        private JCDecauxItem getOneContractResultField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public JCDecauxItem GetOneContractResult
        {
            get
            {
                return this.getOneContractResultField;
            }
            set
            {
                this.getOneContractResultField = value;
            }
        }
    }
}
