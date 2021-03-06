import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { AddressComponent } from './address/address.component';
import { AddressDetailComponent } from './address/address-detail/address-detail.component';
import { HousingComponent } from './housing/housing.component';
import { HousingFormComponent } from './housing/housing-form/housing-form.component';
import { UserComponent } from './user/user.component';
import { FooterComponent } from './footer/footer.component';
import { FindHousingComponent } from './find-housing/find-housing.component';
import { FindRoomatesComponent } from './find-roomates/find-roomates.component';
import { AgmCoreModule } from '@agm/core';
import { IfRoleDirective } from './if-role.directive';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    AddressComponent,
    AddressDetailComponent,
    HousingComponent,
    HousingFormComponent,
    UserComponent,
    FooterComponent,
    FindHousingComponent,
    FindRoomatesComponent,
    IfRoleDirective,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ApiAuthorizationModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'user', component: UserComponent},
      { path: 'address', component: AddressComponent },
      { path: 'housing', component: HousingComponent},
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'find-roomates', component: FindRoomatesComponent },
      { path: 'find-housing', component: FindHousingComponent},
    ]),
    AgmCoreModule.forRoot({
      apiKey: 'AIzaSyC8E8P3h3NcvFGcAFUZ6hvogFLTtv9IL84'
    }),
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
