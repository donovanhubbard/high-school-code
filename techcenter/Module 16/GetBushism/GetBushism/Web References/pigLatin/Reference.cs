﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.1.4322.2032
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 1.1.4322.2032.
// 
namespace GetBushism.pigLatin {
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Web.Services;
    
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="piglatinSoap", Namespace="http://tempuri.org/")]
    public class piglatin : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        /// <remarks/>
        public piglatin() {
            this.Url = "http://www.aspxpressway.com/maincontent/webservices/piglatin.asmx";
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/toPigLatin", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string toPigLatin(string textToTranslate) {
            object[] results = this.Invoke("toPigLatin", new object[] {
                        textToTranslate});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BegintoPigLatin(string textToTranslate, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("toPigLatin", new object[] {
                        textToTranslate}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndtoPigLatin(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
    }
}
