﻿using System.Text.Json.Serialization;

namespace ECommerce.API.DTOs
{
    public class CustomResponseDto<T>

    { 
        public T Data { get; set; }

        [JsonIgnore] //jsona dönüştürürken görmezden gel

        public int StatusCode { get; set; }

        public List<string> Errors { get; set; }

        public static CustomResponseDto<T> Success(int statusCode, T data)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Data = data };
        }

        public static CustomResponseDto<T> Success(int statusCode)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode };
        }

        public static CustomResponseDto<T> Fail(int statusCode, List<string> errors) 
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors = errors };
        }

    }
}
