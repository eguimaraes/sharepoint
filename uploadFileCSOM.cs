private static void exportBatchSharepoint(string website, string username, string password, string path, List<Dir> subdirs)
{
	Folder bfolder;

	try
	{
		if (string.IsNullOrEmpty(website))
			throw new Exception("Error: Sharepoint Not configured correctly.");

		using (Microsoft.SharePoint.Client.ClientContext client = new ClientContext(website))
		{
			System.Diagnostics.Debug.WriteLine("Connecting to Sharepoint site...");

			client.Credentials = new System.Net.NetworkCredential(username, password);
			System.Diagnostics.Debug.WriteLine("Connected.");

			var root_folder = client.Web.GetFolderByServerRelativeUrl(path);
			if (root_folder == null)
				 root_folder = client.Web.Folders.Add(path);

			System.Diagnostics.Debug.WriteLine("\tCreating Sharepoint Sub-Directory \"" + path + "\".");

			foreach (var dir in subdirs)
			{
				string dir_path = Uri.EscapeUriString(dir.name).Replace("?", "_");
				System.Diagnostics.Debug.WriteLine("\t\tCreating Document Directory \"" + dir_path + "\".");

				var dir_folder = root_folder.Folders.Add(dir_path);

				foreach (var doc in dir.documents)
				{
					string doc_path = Path.GetFileName(doc);

					var uplfileStream = System.IO.File.ReadAllBytes(doc);
					dir_folder.Files.Add(new FileCreationInformation()
					{
						Content = uplfileStream,
						Overwrite = true,
						Url = doc_path
					});
				}

			}

			System.Diagnostics.Debug.WriteLine("\tUploading to Sharepoint Server is Done.");
		}
	}
	catch (Exception ex)
	{
		System.Diagnostics.Debug.WriteLine("ERROR: " + ex.Message);
	}
}
