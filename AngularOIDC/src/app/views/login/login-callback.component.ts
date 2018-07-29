import { Component, OnInit } from '@angular/core';
import { OAuthService, AuthConfig } from "angular-oauth2-oidc";
import { Router } from "@angular/router";

@Component({
    template: ''
})
export class LoginCallbackComponent implements OnInit {

    constructor(private oauthService: OAuthService, private router: Router) {}

    ngOnInit() {
        this.oauthService.loadDiscoveryDocumentAndTryLogin().then(_ => {
            if (!this.oauthService.hasValidIdToken() || !this.oauthService.hasValidAccessToken()) {
                this.oauthService.initImplicitFlow('login');
            } else {
                this.router.navigate(["/dashboard"]);
            }
        });
    }
}