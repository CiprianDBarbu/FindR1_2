import { Directive, Input, OnDestroy, OnInit, TemplateRef, ViewContainerRef } from '@angular/core';
import { Subscription } from 'rxjs';

@Directive({
  selector: '[IfRole]'
})
export class IfRoleDirective implements OnInit, OnDestroy{

  private subscription: Subscription[] = [];
  roles = ["User", "Administrator"];

  @Input() public IfRole: Array<string>;

  constructor() { }

  public ngOnInit() {
   

  }

  public ngOnDestroy() {

  }
}
