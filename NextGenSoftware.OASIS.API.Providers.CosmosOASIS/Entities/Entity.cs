﻿using System;

namespace NextGenSoftware.OASIS.API.Providers.CosmosOASIS.Entites
{
	public abstract class Entity
	{
		/// <summary>
		/// Entity identifier
		/// </summary>
		/// <example>5fe3fc2a-cbac-4df0-8031-fdca0f682989</example>
		public Guid Id { get; set; }
	}
}
