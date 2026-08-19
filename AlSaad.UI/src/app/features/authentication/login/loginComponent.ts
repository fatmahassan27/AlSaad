import { Component, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../../core/services/AuthService';

@Component({
  selector: 'app-loginComponent',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterLink],
  templateUrl: './loginComponent.html',
  styleUrl: './loginComponent.css'
})
export class LoginComponent {
  private fb = inject(FormBuilder);
  private authService = inject(AuthService);
  private router = inject(Router);

  readonly form = this.fb.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required, Validators.minLength(6)]]
  });

  readonly isSubmitting = signal(false);
  readonly errorMessage = signal<string | null>(null);

  onSubmit(): void {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    this.isSubmitting.set(true);
    this.errorMessage.set(null);

    const { email, password } = this.form.getRawValue();

    this.authService.login({ email: email!, password: password! }).subscribe({
      // next: (AuthResponse) => {
      //   console.log('LOGIN SUCCESS:', Response);
      //   this.router.navigate(['/home']);
      // },
      next: (response) => {
  console.log('SUCCESS FROM ANGULAR');
  console.log(response);

  this.router.navigate(['/home'])
    .then(result => {
      console.log('NAVIGATION RESULT:', result);
    });
},
      error: (err) => {
      console.log('LOGIN ERROR:', err);
      }
    });
  }
}