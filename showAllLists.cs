using System;
using Microsoft.SharePoint;
namespace ekis{
class Program {
static void Main() {
const string siteUrl = "http://intranet.ekis.com.br";|
using (SPSite siteCollection = new SPSite(siteUrl)) {
SPWeb site = siteCollection.RootWeb;
foreach (SPList list in site.Lists) {
if (!list.Hidden) {
Console.WriteLine(list.Title);
}
}
}
}
}
}
