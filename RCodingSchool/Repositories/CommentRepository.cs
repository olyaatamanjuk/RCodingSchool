﻿using RCodingSchool.Models;
using System.Linq;
using RCodingSchool.Interfaces;

namespace RCodingSchool.Repositories
{
	public class CommentRepository : Repository<Comment>, ICommentRepository
	{
		public CommentRepository(RCodingSchoolContext context)
            : base(context)
        {
		}
		public override Comment Get(int id)
		{
			return dbContext.Comments.Include("User").FirstOrDefault(x => x.Id == id);
		}
	}
}