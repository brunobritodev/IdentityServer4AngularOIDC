import { Component, OnInit } from '@angular/core';
import { OAuthService, AuthConfig } from "angular-oauth2-oidc";
import { Router } from "@angular/router";
import { authConfig } from '../../core/auth/auth.config';

@Component({
    template: ''
})
export class LoginCallbackComponent implements OnInit {

    constructor(private oauthService: OAuthService, private router: Router) {
    }

    ngOnInit() {
        this.oauthService.loadDiscoveryDocument().then(() => {

            // This method just tries to parse the token(s) within the url when
            // the auth-server redirects the user back to the web-app
            // It dosn't send the user the the login page
            this.oauthService.tryLogin({onTokenReceived: () => this.router.navigate(["/dashboard"])});
      
          });
        
    }
}