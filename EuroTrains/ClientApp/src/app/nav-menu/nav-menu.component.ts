import { Component } from '@angular/core';
import { AuthService } from './../auth/auth.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;

  fullNameUser = '';

  constructor(public authService: AuthService) { }

  //ngOnInit(): void {


  //  this.fullNameUser = this.authService.currentUser?.fullName ?? '';

  //}

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
