﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCore_DB.Models;
using Microsoft.EntityFrameworkCore;


namespace ASPNETCore_DB
{

    public class PaginatedList<T> : List<T>
    {

        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            this.AddRange(items);
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }

        public static PaginatedList<T> Create(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }

        internal static async Task<string> CreateAsync(IQueryable<Student> students, int v1, int v2)
        {
            throw new NotImplementedException();
        }

        internal string Create(IQueryable<Consumer> consumers, int v, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
