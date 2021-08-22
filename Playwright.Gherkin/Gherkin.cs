using System;
using System.Threading.Tasks;

namespace Playwright.Gherkin
{
    public static class Gherkin
    {
        public static async Task<TResult> Given<TResult>(
            Func<Task<TResult>> fn) => await fn();
        
        public static async Task<TResult> When<TSource, TResult>(
            this Task<TSource> @this,
            Func<TSource, Task<TResult>> fn) => await fn(await @this);
        
        public static async Task<TResult> And<TSource, TResult>(
            this Task<TSource> @this,
            Func<TSource, Task<TResult>> fn) => await fn(await @this);
        
        public static async Task<TResult> Then<TSource, TResult>(
            this Task<TSource> @this,
            Func<TSource, Task<TResult>> fn) => await fn(await @this);
        
        public static async Task Then<TSource>(
            this Task<TSource> @this,
            Func<TSource, Task> fn) => await fn(await @this);

        public static async Task<TResult> MapAsync<TSource, TResult>(
            this Task<TSource> @this,
            Func<TSource, Task<TResult>> fn) => await fn(await @this);
        
        public static async Task MapAsync<TSource>(
            this Task<TSource> @this,
            Func<TSource, Task> fn) => await fn(await @this);
    }
}