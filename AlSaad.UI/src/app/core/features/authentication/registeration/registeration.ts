import { CommonModule } from '@angular/common';
import { Component ,inject ,signal } from '@angular/core';
import { ReactiveFormsModule ,FormBuilder,Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../../services/AuthService';


@Component({
  selector: 'app-registeration',
  standalone:true,
  imports: [CommonModule,ReactiveFormsModule],
  templateUrl: './registeration.html',
  styleUrl: './registeration.css',
})
export class Registeration {



private fb = inject(FormBuilder);
  private authService = inject(AuthService);
  private router = inject(Router);

  readonly isSubmitting = signal(false);
  readonly errorMessage = signal<string | null>(null);
  readonly successMessage = signal<string | null>(null);

  readonly form = this.fb.group({
    fullName: ['', Validators.required],
    UserName: ['', Validators.required],
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required, Validators.minLength(6)]],
    phoneNumber: ['', Validators.required]
  });

  onSubmit(): void {

    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    this.isSubmitting.set(true);
    this.errorMessage.set(null);
    this.successMessage.set(null);

    const { fullName, UserName, email, password, phoneNumber } =
      this.form.getRawValue();

    this.authService.register({
      fullName: fullName!,
      UserName: UserName!,
      email: email!,
      password: password!,
      phoneNumber: phoneNumber!
    }).subscribe({

      next: (response) => {
        console.log('REGISTER SUCCESS:', response);

        this.isSubmitting.set(false);
        this.successMessage.set('Account created successfully.');

        // مؤقتًا بعد التسجيل نرجع للـ Login
        setTimeout(() => {
          this.router.navigate(['/login']);
        }, 1000);
      },

      error: (err) => {
        console.log('REGISTER ERROR:', err);

        this.isSubmitting.set(false);

        this.errorMessage.set(
          err.error?.message ?? 'Registration failed.'
        );
      }
    });
  }



}
