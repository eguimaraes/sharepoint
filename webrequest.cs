using System;
using System.Web;
using System.Net;
using System.Xml;
using System.Collections;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;

WebRequest webRequest = WebRequest.Create(uri);
webRequest.Credentials = CredentialCache.DefaultCredentials;
webRequest.Method ="GET";
HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
System.Net.HttpWebRequest
