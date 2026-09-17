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

  @Output() menuToggle = new EventEmitter<void>();

  cartItemsCount = 3;

  toggleMenu(): void {
    console.log('MENU CLICKED');
    this.menuToggle.emit();
  }

  logout(): void {
    console.log('Logout');
  }
}