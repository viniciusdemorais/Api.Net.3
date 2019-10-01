using System.Collections.Generic;

namespace Api.Core.Models
{
	public class BaseResponse<T>
	{
		public T Object { get; set; }
		public string Message { get; set; }
		public bool Success { get; set; }

		public BaseResponse()
		{
			Message = string.Empty;
			Success = true;
		}

		public class Collection
		{
			public List<T> List { get; set; }
			public string Message { get; set; }
			public bool Success { get; set; }
			public int? Total { get; set; }

			public Collection()
			{
				Success = true;
				Message = string.Empty;
				List = new List<T>();
			}
		}
	}
}

