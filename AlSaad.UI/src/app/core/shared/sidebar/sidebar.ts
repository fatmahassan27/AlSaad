import { Component ,EventEmitter, Input , Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { Category } from '../../models/Category';

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule
  ],
  templateUrl: './sidebar.html',
  styleUrl: './sidebar.css'
})
export class Sidebar {
   @Input() isOpen = false;
  @Output() close = new EventEmitter<void>();
  private openSubmenus = new Set<string>();
 categories: Category[]=[
 {
      label: 'زيوت وفلاتر',
      path: '/oils-filters'
    },
    {
      label: 'فرامل',
      path: '/brakes'
    },
    {
      label: 'كهرباء',
      path: '/electrical'
    },
    {
      label: 'إطارات',
      path: '/tires'
    },
    {
      label: 'عفشة',
      path: '/suspension'
    },{ label: 'قوالب الوحدات', path: '/inventory/unit-templates' }
 ]
  // فتح / قفل الـ Sidebar
  closeSidebar(): void {
    this.close.emit();
  }


  // فتح / قفل الـ Submenu
     toggleSubmenu(category: Category): void { 
   if (!category.children) 
    { return; }
    const key = category.label; 
    if (this.openSubmenus.has(key)) { 
     this.openSubmenus.delete(key); } 
     else {this.openSubmenus.add(key); }
     }

     isSubmenuOpen(category: Category): boolean {
 
     return this.openSubmenus.has(category.label);
  }


  // تسجيل الخروج
  logout(): void {

    localStorage.removeItem('alsaad_token');
    localStorage.removeItem('alsaad_user');

    this.closeSidebar();

    // لو عندك AuthService للـ logout هنستخدمه هنا بدل الكود ده
  }

 toggleSidebar(): void {
  this.isOpen = !this.isOpen;

  console.log('SIDEBAR STATE:', this.isOpen);
}



}