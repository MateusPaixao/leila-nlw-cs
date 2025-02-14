﻿using leilaoSolution.API.Contracts;
using leilaoSolution.API.Entities;

namespace leilaoSolution.API.Services;

public class LoggedUser: ILoggedUser
{
    private IHttpContextAccessor _httpContextAccessor;
    private IUserRepository _repository;
    // constructor
    public LoggedUser(IHttpContextAccessor httpContext, IUserRepository repository) {
        _httpContextAccessor = httpContext;
        _repository = repository;
    } 

    public User User()
    {
        var token = TokenOnRequest();
        var email = FromBase64String(token);
        return _repository.GetUserByEmail(email);
    }

    private string TokenOnRequest()
    {
        var authentication = _httpContextAccessor.HttpContext!.Request.Headers.Authorization.ToString();

        return authentication["Bearer ".Length..];
    }

    private string FromBase64String(string base64)
    {
        var data = Convert.FromBase64String(base64);
        return System.Text.Encoding.UTF8.GetString(data);
    }
}
