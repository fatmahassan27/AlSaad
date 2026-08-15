import { Service } from '@angular/core';
import { Injectable, signal, computed } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable, tap } from 'rxjs';
import { AuthResponse, AuthUser, LoginRequest, RegisterRequest } from '../models/authentication-models';
import { environment } from '../../../environments/environment';
const TOKEN_KEY = 'alsaad_token';
const USER_KEY = 'alsaad_user';

@Injectable({
  providedIn: 'root'
})
export class AuthService
{
      private readonly currentUserSignal = signal<AuthUser | null>(this.readUserFromStorage());
      readonly currentUser = computed(() => this.currentUserSignal());
      readonly isLoggedIn = computed(() => this.currentUserSignal() !== null);
      constructor(private http: HttpClient, private router: Router) { }

  register(dto: RegisterRequest): Observable<AuthResponse> {
    return this.http
      .post<AuthResponse>(`${environment.apiUrl}/auth/register`, dto)
      .pipe(tap((res) => this.persistSession(res)));
  }
   login(dto: LoginRequest): Observable<AuthResponse> {
    return this.http
      .post<AuthResponse>(`${environment.apiUrl}/auth/login`, dto)
      .pipe(tap((res) => this.persistSession(res)));
  }
  logout(): void {
    localStorage.removeItem(TOKEN_KEY);
    localStorage.removeItem(USER_KEY);
    this.currentUserSignal.set(null);
    this.router.navigate(['/login']);
  }
   getToken(): string | null {
    return localStorage.getItem(TOKEN_KEY);
  }
  private persistSession(res: AuthResponse): void {
    localStorage.setItem(TOKEN_KEY, res.accessToken);
    localStorage.setItem(USER_KEY, JSON.stringify(res.user));
    this.currentUserSignal.set(res.user);
  }
  private readUserFromStorage(): AuthUser | null {
    const raw = localStorage.getItem(USER_KEY);
    if (!raw) return null;
    try {
      return JSON.parse(raw) as AuthUser;
    } catch 
    {
      return null;
    }
  
}
}