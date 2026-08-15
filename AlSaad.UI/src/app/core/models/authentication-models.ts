
export interface RegisterRequest {
  fullName: string;
  UserName : string;
  email: string;
  password: string;
  phoneNumber: string;
}

export interface LoginRequest {
  email: string;
  password: string;
}

export interface AuthUser {
  UserName: string;
  fullName: string;
  email: string;
  role: string;
}

export interface AuthResponse {
  accessToken: string;
  user: AuthUser;
  Success : boolean;
  Message: string;
  token:string;
  ExpiresDate:Date;
}