using System.Collections.Generic;

namespace HalApp
{
	public class Resource
	{
		public object Content { get; set; }
		public IList<Link> Links { get; set; }
		public IList<Resource> Embedded { get; set; }
	}

	public class Resource<T> : Resource
	{
		public new T Content
		{
			get { return (T) base.Content; }
			set { base.Content = value; }
		}
	}

	public class Link
	{
		public string Rel { get; set; }
		public string Href { get; set; }
	}
}