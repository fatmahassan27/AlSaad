import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { Footer } from '../footer/footer';  
import {Sidebar} from  '../sidebar/sidebar';
import { NewHeader } from '../new-header/new-header';

@Component({
  selector: 'app-mainlayout',
  imports: [CommonModule, RouterModule, Footer, Sidebar, NewHeader],
  templateUrl: './mainlayout.html',
  styleUrl: './mainlayout.css',
})
export class Mainlayout {
}
