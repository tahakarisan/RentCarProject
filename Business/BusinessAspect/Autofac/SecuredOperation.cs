﻿using Business.Constant;
using Castle.DynamicProxy;
using CoreLayer.Extensions;
using CoreLayer.Utilities.Interceptors;
using CoreLayer.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessAspect.Autofac
{
   
    public class SecuredOperation : MethodInterception
    {
        public string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;
        public SecuredOperation(string roles)
        {
            _roles = roles.Split(",");
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (role.Contains(role))
                {
                    return;
                }

                throw new Exception("Yetki yok");
            }
        }
    }
}