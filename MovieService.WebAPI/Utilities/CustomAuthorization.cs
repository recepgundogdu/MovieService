using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MovieService.Core.Models.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MovieService.WebAPI.Utilities
{
    public class CustomAuthorization : Attribute, IAuthorizationFilter
    {
        public string _role { get; set; }
        public CustomAuthorization()
        {
        }
        public CustomAuthorization(string role)
        {
            _role = role;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;
            if (user != null)
            {
                if (user.Identity.IsAuthenticated)
                {
                    if (!user.HasClaim(x => x.Type == ClaimTypes.Role && x.Value == _role) && !string.IsNullOrEmpty(_role))
                    {
                        context.Result = new JsonResult("NotAuthorized")
                        {
                            Value = new
                            {
                                Data = DBNull.Value,
                                Success = false,
                                Message = Messages.Unauthorized
                            },
                        };
                        context.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                    }
                }
                else
                {
                    context.Result = new JsonResult("NotAuthorized")
                    {
                        Value = new
                        {
                            Data = DBNull.Value,
                            Success = false,
                            Message = Messages.Unauthorized
                        },
                    };
                    context.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;

                }
            }
            else
            {
                context.Result = new JsonResult("NotAuthorized")
                {
                    Value = new
                    {
                        Data = DBNull.Value,
                        Success = false,
                        Message = Messages.Unauthorized
                    },
                };
                context.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
            }

        }
    }
}
