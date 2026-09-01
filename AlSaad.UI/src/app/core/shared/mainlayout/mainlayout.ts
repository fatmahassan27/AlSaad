import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { Header } from '../header/header';
import { Footer } from '../footer/footer';  
import {Sidebar} from  '../sidebar/sidebar';

@Component({
  selector: 'app-mainlayout',
  imports: [CommonModule, RouterModule, Header,Footer,Sidebar],
  templateUrl: './mainlayout.html',
  styleUrl: './mainlayout.css',
})
export class Mainlayout {

 sidebarOpen = false;

  toggleSidenav(): void {
    this.sidebarOpen = !this.sidebarOpen;
  }

  closeSidenav(): void {
    this.sidebarOpen = false;
  }
}
