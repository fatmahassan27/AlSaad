import { Injectable, signal, computed, inject, PLATFORM_ID } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable, tap } from 'rxjs';
import { environment } from '../../../environments/environment';
import { AuthResponse, AuthUser, LoginRequest, RegisterRequest } from '../models/authentication-models';

const TOKEN_KEY = 'alsaad_token';
const USER_KEY = 'alsaad_user';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private platformId = inject(PLATFORM_ID);
  private isBrowser = isPlatformBrowser(this.platformId);

  private readonly currentUserSignal = signal<AuthUser | null>(this.readUserFromStorage());
  readonly currentUser = computed(() => this.currentUserSignal());
  readonly isLoggedIn = computed(() => this.currentUserSignal() !== null);

  constructor(private http: HttpClient, private router: Router) { }

  register(dto: RegisterRequest): Observable<AuthResponse> {
    return this.http
      .post<AuthResponse>(`${environment.apiUrl}/Authentication/Register`, dto)
      .pipe(tap((res) => this.persistSession(res)));
  }

  login(dto: LoginRequest): Observable<AuthResponse> {
    return this.http
      .post<AuthResponse>(`${environment.apiUrl}/Authentication/Login`, dto)
      .pipe(tap((res) => this.persistSession(res)));
  }

  logout(): void {
    if (this.isBrowser) {
      localStorage.removeItem(TOKEN_KEY);
      localStorage.removeItem(USER_KEY);
    }
    this.currentUserSignal.set(null);
    this.router.navigate(['/login']);
  }

  getToken(): string | null {
    if (!this.isBrowser) return null;
    return localStorage.getItem(TOKEN_KEY);
  }

  private persistSession(res: AuthResponse): void {
    if (!this.isBrowser) return;
      localStorage.setItem(TOKEN_KEY, res.token);
      localStorage.setItem(USER_KEY,JSON.stringify(res.user));

      this.currentUserSignal.set(res.user);

  }

  private readUserFromStorage(): AuthUser | null {
    if (!this.isBrowser) return null;
    const raw = localStorage.getItem(USER_KEY);
    if (!raw) return null;
    try {
      return JSON.parse(raw) as AuthUser;
    } catch {
      return null;
    }
  }
}