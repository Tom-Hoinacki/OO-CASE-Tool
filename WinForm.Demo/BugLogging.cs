using System;
using System.Threading;
using System.Collections;
using System.Data;
namespace Netron.NetronLight.Demo
{
	/// <summary>
	/// Helper class to log bugs from the diagram control to the Netron bug-logging service.
    /// No personal information is recorded, only the exception thrown is send to the webservice.
    /// 
	/// </summary>
	public class BugLogging
	{
		#region Fields
		static Queue bugQueue = new Queue();
		static DataSet ds = new DataSet();
		static int amount = 100;
		struct Bug
		{
			public string Title;
			public string Comment;

			public Bug(string title, string comment)
			{
				Title = title;
				Comment = comment;
			}
		}
		#endregion

		#region Constructor
		public BugLogging()
		{
			
		}
		#endregion

		#region GetBugs
		public static DataSet GetBugs(int top)
		{
			
			
			try
			{
				amount = top;
				//Run in new thread.
				AutoResetEvent isDone = new AutoResetEvent(false);				
				ThreadPool.QueueUserWorkItem(new WaitCallback(AsyncGetBugs), isDone);				
				
				
				WaitHandle.WaitAll(new AutoResetEvent[]{isDone});

				
			}
			catch
			{}

			return ds;
		}

		private static void AsyncGetBugs(object state)
		{
			try
			{
				BugWS.NetronWS logger = new BugWS.NetronWS();
				string[] bugs = logger.ListBugs(amount.ToString());
				DataTable dt;
			
				if(bugs.Length>0)
				{
					ds = new DataSet();
					dt = ds.Tables.Add("Bugs");
					dt.Columns.Add("Id");
					dt.Columns.Add("Created");
					dt.Columns.Add("Title");
					dt.Columns.Add("Text");

					for(int k =0; k<bugs.Length; k++)
					{
						try
						{
							dt.Rows.Add(bugs[k].Split('|'));
						}
						catch
						{continue;}
					}
					

				}
			}
			catch
			{}
			// Signal that thread is done.
			((AutoResetEvent)state).Set();
		}
		#endregion

		#region GetAllBugs

		public static DataSet GetAllBugs()
		{
			
			
			try
			{
				//Run in new thread.
				AutoResetEvent isDone = new AutoResetEvent(false);				
				ThreadPool.QueueUserWorkItem(new WaitCallback(AsyncGetAllBugs), isDone);				
				
				
				WaitHandle.WaitAll(new AutoResetEvent[]{isDone});

				
			}
			catch
			{}

			return ds;
		}

		private static void AsyncGetAllBugs(object state)
		{
			try
			{
			BugWS.NetronWS logger = new BugWS.NetronWS();
			string[] bugs = logger.ListBugs("5000");
			DataTable dt;
			
				if(bugs.Length>0)
				{
					ds = new DataSet();
					dt = ds.Tables.Add("Bugs");
					dt.Columns.Add("bugid");
					dt.Columns.Add("created");
					dt.Columns.Add("bugtitle");
					dt.Columns.Add("bugtext");

					for(int k =0; k<bugs.Length; k++)
					{
						try
						{
							dt.Rows.Add(bugs[k].Split('|'));
						}
						catch
						{continue;}
					}
					

				}
			}
			catch
			{}
			// Signal that thread is done.
			((AutoResetEvent)state).Set();
		}


		#endregion

		#region AddBug
		public static string AddBug(string title, string comment)
		{
			string ret = string.Empty;
			try
			{
				bugQueue.Enqueue(new Bug(title, comment));
				//Run in new thread.
				AutoResetEvent isDone = new AutoResetEvent(false);				
				ThreadPool.QueueUserWorkItem(new WaitCallback(AsyncAddBug), isDone);				
				ret = "The bug has been logged, thank you!";			
			}

			catch(Exception exc)
			{
				ret = exc.Message;
			}
			return ret;

		}

		private static void AsyncAddBug(object state)
		{
			try
			{

				BugWS.NetronWS logger = new BugWS.NetronWS();
                logger.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
				Bug b = (Bug) bugQueue.Dequeue();
			
				logger.AddBug(b.Title, b.Comment);

			
			}
			catch(Exception exc)
			{
                
                System.Diagnostics.Trace.WriteLine(exc.Message);
			}
			// Signal that thread is done.
			((AutoResetEvent)state).Set();
		}

		#endregion
	}
}
