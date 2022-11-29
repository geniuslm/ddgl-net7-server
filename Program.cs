using 命名空间Hub;


var builder = WebApplication.CreateBuilder(args);
//将服务添加到容器中.
builder.Services.AddRazorPages();
builder.Services.AddSignalR();

builder.Services.AddCors(options =>
    {
        options.AddPolicy(name: "Cors策略",
                          policy策略 =>
                          {
                              policy策略
                              .SetIsOriginAllowed(origin => true)
                              .AllowAnyHeader()
                              .AllowAnyMethod()
                              .AllowCredentials();
                          }
                          );

    }
);


var app = builder.Build();

// 配置 HTTP 请求管道.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseStaticFiles();

app.UseRouting();
//UseCors必须放在 UseRouting 和 UseAuthorization 之前
app.UseCors("Cors策略");


app.UseAuthorization();


app.MapRazorPages();
//MapHub必须在UseCors 之后
app.MapHub<api中心Hub>("/signalr");

app.Run();
