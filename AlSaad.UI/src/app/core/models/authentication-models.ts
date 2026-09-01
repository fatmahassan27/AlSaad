
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
    success: boolean;
    message: string;
    token: string;
    expiresDate: Date | null;
    user: AuthUser;

}