﻿using DevJobs.Data.Repositories;
using DevJobs.Data.SaveContext;
using DevJobs.Models.Models;
using DevJobs.Servicess.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevJobs.Servicess
{
    public class LevelService : IService, ILevelService
    {
        private readonly IEfRepository<Level> levelRepo;
        private readonly ISaveContext context;

        public LevelService(IEfRepository<Level> levelRepo, ISaveContext context)
        {
            this.levelRepo = levelRepo;
            this.context = context;
        }

        public IQueryable<Level> GetAll()
        {
            return this.levelRepo.All;
        }

        public IQueryable<Level> GetAllAndDeleted()
        {
            return this.levelRepo.AllAndDeleted;
        }

        public void Add(Level level)
        {
            this.levelRepo.Add(level);
            this.context.Commit();
        }
            
        public void Update(Level level)
        {
            this.levelRepo.Update(level);
            this.context.Commit();
        }
    }
}

