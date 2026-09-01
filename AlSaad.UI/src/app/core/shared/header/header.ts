import { Component, EventEmitter, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule
  ],
  templateUrl: './header.html',
  styleUrls: ['./header.css']
})
export class Header {
  @Output() toggleSidebar = new EventEmitter<void>();

  cartItemsCount = 3;

navLinks = [
  { label: 'الرئيسية', path: '/home' },
  { label: 'قطع الغيار', path: '/makers' },
  { label: 'الموديلات', path: '/models' }
];

  onToggleSidebar(): void {
    this.toggleSidebar.emit();
  }
}