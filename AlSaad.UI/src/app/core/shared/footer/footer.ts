import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-footer',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './footer.html',
  styleUrls: ['./footer.css']
})
export class Footer {
  currentYear = new Date().getFullYear();

  quickLinks = [
    { label: 'الرئيسية', path: '/' },
    { label: 'قطع الغيار', path: '/makers' },
    { label: 'عروض خاصة', path: '/offers' },
    { label: 'حسابي', path: '/account' }
  ];
}