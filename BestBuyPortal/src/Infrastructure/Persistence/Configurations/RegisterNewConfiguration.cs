﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.Configurations
{
    public class RegisterNewConfiguration : IEntityTypeConfiguration<RegisterNew>
    {
        public void Configure(EntityTypeBuilder<RegisterNew> builder)
        {
            
        }
    }
}
