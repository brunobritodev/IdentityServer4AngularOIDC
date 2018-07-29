import { Component } from '@angular/core';
import { OAuthService } from 'angular-oauth2-oidc';

@Component({
  selector: 'app-dashboard',
  templateUrl: 'login.component.html'
})
export class LoginComponent { 
  constructor(private oauthService: OAuthService) {
  }

  public login() {
      this.oauthService.initImplicitFlow("login");
  }

}
