import { Component } from '@angular/core';
import { AuthService } from "app/services/auth.service";
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  userName = localStorage.getItem('userMail');

  constructor(private authService : AuthService,
              private router: Router) {}

    logout(){
    if (this.authService.isLoggedIn()){
      this.authService.logout();
      this.router.navigate(['/login']);
    }
  }
  
  isLoggedIn(){
    return this.authService.isLoggedIn();
  }
}
