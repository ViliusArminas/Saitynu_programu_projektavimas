import { Component, OnInit } from '@angular/core';
import { AuthService } from "app/services/auth.service";
import { Router } from '@angular/router';
import { environment } from 'environments/environment';
import { Http, RequestOptions } from '@angular/http';
import {Headers} from '@angular/http';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  username: string;
  password: string;

  wrongCredentials: boolean = false;
  loggedOut: boolean = false;

  constructor(private authService: AuthService,
              private router: Router,
              private http: Http) { }

  ngOnInit() {
  }

  login() {
    this.wrongCredentials = false;
    this.authService.login(this.username, this.password).then(() => {
      if (this.authService.isLoggedIn()) {
        let authToken = localStorage.getItem('access_token');
        let headers = new Headers({ 'Accept': 'application/json' });
        headers.append('Authorization', `Bearer ${authToken}`);
        console.log(headers);
        let options = new RequestOptions({ headers: headers });
        this.http.get(environment.backEndPoint + '/api/Account/UserInfo', options).subscribe((data:any) => {
          let d: any = JSON.parse(data._body);
          localStorage.setItem('userMail', d.email);
        });
        this.router.navigate(['/']);

      } else {
        this.wrongCredentials = true;
      }
    });
  }

  logout() {
    this.loggedOut = false;
    if (this.authService.isLoggedIn()) {
      this.loggedOut = true;
      this.authService.logout();
    }

  }

  googleLogin() {
    window.location.href='http://localhost:49974/api/Account/ExternalLogin?provider=Google&response_type=token&client_id=self&redirect_uri=http%3A%2F%2Flocalhost%3A49974%2Fbuild-workout%2Fnew&state=k_P1QEqIzH6n0wu4JNBFEBshvpzfMI9nn6xOXIxm8e41';
  }


}
