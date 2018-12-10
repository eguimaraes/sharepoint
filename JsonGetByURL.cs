//https://www.codeproject.com/Tips/397574/%2FTips%2F397574%2FUse-Csharp-to-get-JSON-Data-from-the-Web-and-Map-i
using System.Net;
using Newtonsoft.Json;

// ...

private static T _download_serialized_json_data<T>(string url) where T : new() {
  using (var w = new WebClient()) {
    var json_data = string.Empty;
    // attempt to download JSON data as a string
    try {
      json_data = w.DownloadString(url);
    }
    catch (Exception) {}
    // if string with JSON data is not empty, deserialize it to class and return its instance 
    return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
  }
}
