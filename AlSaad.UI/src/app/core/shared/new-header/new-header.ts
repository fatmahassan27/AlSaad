import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-new-header',
  imports: [CommonModule,
    RouterModule
  ],
  templateUrl: './new-header.html',
  styleUrl: './new-header.css',
})
export class NewHeader {}
