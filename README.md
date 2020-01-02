# Simplerjiang.AspnetCoreEmailSender

用于asp.net core 的Smtp EmailSender

Easy way to Smtp

---

Nuget:[![Simplerjiang.AspnetCoreEmailSender](https://img.shields.io/nuget/v/Simplerjiang.AspnetCoreEmailSender)](https://www.nuget.org/packages/Simplerjiang.AspnetCoreEmailSender/)
[![Simplerjiang.AspnetCoreEmailSender](https://img.shields.io/nuget/dt/Simplerjiang.AspnetCoreEmailSender)](https://www.nuget.org/packages/Simplerjiang.AspnetCoreEmailSender/)

---

## 快速使用 Quick Start

将下面代码加入到 Startup.cs 中的 ConfigureServices 方法中

Add the code to Startup.cs , Method "ConfigureServices"

```c#
            services.AddScoped<IEmailSender, EmailSender>(sp => {
                var emailSetting = new EmailSettings(); //Create your settings instance
                emailSetting.MailServer = "smtp.qq.com";
                emailSetting.UseSSH = true;
                emailSetting.MailPort = 465;
                emailSetting.Sender = "YourAccount";
                emailSetting.SenderName = "SenderName";
                emailSetting.Password = "pwd";
                emailSetting.ToNickName = "receiver";
                return new EmailSender(emailSetting);
            });
```

IEmailSender 会通过注入的方式传递到控制器中。
IEmailSender will put in to controller by inject way.


```c#
    public class HomeController : Controller
    {
        private readonly IEmailSender _sender;
        public HomeController(IEmailSender sender)
        {
            _sender = sender;
        }

        public async Task<IActionResult> Test()
        {
            await _sender.SendEmailAsync("1013171256@qq.com", "Subject", "Message Or Html");
            return Ok();
        }
    }
```

如果你想通过appsettings.json 方法加载配置也可以
It's able to load the setting by Configuration.GetSection() from appsettings.json

```c#
services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
```

有问题请提ISSUE或者PR
