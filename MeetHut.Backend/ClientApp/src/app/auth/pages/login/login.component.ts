import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LoginModel } from '../../models';
import { AuthService } from '../../services';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  public loginModel: LoginModel = new LoginModel('', '');
  private redirectPath = '/home';

  constructor(
    private authService: AuthService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  // TODO: Redirect parameter

  ngOnInit(): void {
    this.route.queryParams.subscribe(
      (params) => (this.redirectPath = params.redirect || '/home')
    );
  }

  login() {
    this.authService
      .login(this.loginModel)
      .then(() => {
        this.loginModel = new LoginModel('', '');
        this.router.navigateByUrl(this.redirectPath);
      })
      .catch((err) => console.log(err));
  }
}
