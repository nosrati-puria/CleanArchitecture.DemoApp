using System;

namespace Domain.Shared;

public static class Utility
{
	#region Static Constructor

	static Utility()
	{
	}

	#endregion /Static Constructor

	//*************************

	#region Consts

	public sealed class Const
	{
		#region Constructor

		/// <summary>
		/// Constructor
		/// </summary>
		private Const()
		{
		}

		#endregion /Constructor

		public const byte AgeMinLength = 0;

		public const byte AgeMaxLength = 120;

		public const int EmailMaxLength = 100;

		public const int ReasonMinLength = 10;

		public const int ReasonMaxLength = 3000;

		public const byte UsernameMinLength = 3;

		public const byte UsernameMaxLength = 30;

		public const byte RoleNameMinLength = 3;

		public const byte RoleNameMaxLength = 50;

		public const byte PasswordMinLength = 8;

		public const byte PasswordMaxLength = 20;

		public const byte FullNameMinLength = 100;

		public const byte FullNameMaxLength = 100;

		public const int DescriptionMaxLength = 500;


		public const string DefaultConnection = "DefaultConnection";
	}
	#endregion /Consts

	//*************************

	#region Regex
	public sealed class Regex
	{
		#region Constructor

		/// <summary>
		/// Constructor
		/// </summary>
		private Regex()
		{
		}

		#endregion /Constructor

		public const string CellPhoneNumber = "^(09|\\+989|00989)[0-9]{9}$";

		public const string Email = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$";
	}
	#endregion /Regex

	//*************************

	#region PasswordHasher

	public static class Hasher
	{
		public static string GetHash(string input)
		{
			var bytes = System.Text.Encoding.UTF8.GetBytes(input);
			var hashBytes = System.Security.Cryptography.SHA256.HashData(bytes);
			var output = Convert.ToBase64String(hashBytes);

			return output;
		}
	}

	#endregion /PasswordHasher

	//*************************
}