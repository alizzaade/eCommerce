import { Component } from '@angular/core';
import { MatButton } from '@angular/material/button';
import { MatFormField, MatInput, MatLabel } from '@angular/material/input';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-order-summary',
  imports: [RouterLink, MatButton, MatFormField, MatInput, MatLabel],
  templateUrl: './order-summary.component.html',
  styleUrl: './order-summary.component.scss',
})
export class OrderSummaryComponent {}
