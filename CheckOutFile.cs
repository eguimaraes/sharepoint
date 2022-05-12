 //https://csharp.hotexamples.com/pt/examples/-/SPFile/CheckOut/php-spfile-checkout-method-examples.html
 public static void CheckOutFile(SPFile homePageFile)
 {
     try
     {
         if (homePageFile.CheckOutStatus == SPFile.SPCheckOutStatus.None)
             homePageFile.CheckOut();
     }
     catch (Exception ee)
     {
         EssnLog.logInfo("Error on CheckOutFile in FeatureActivated.");
         EssnLog.logExc(ee);
     }
 }
