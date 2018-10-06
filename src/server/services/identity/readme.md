### Identity Service

#### POST `/api/auth/login`

登录请求：
```json
{
  "login": "登录名",
  "password": "密码"
}
```

#### POST `/api/auth/register`

注册请求：

```json
{
  "username": "用户名",
  "email": "邮箱",
  "password": "不少于6位数密码"
}
```