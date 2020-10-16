(function(t){function e(e){for(var n,s,l=e[0],i=e[1],c=e[2],h=0,p=[];h<l.length;h++)s=l[h],Object.prototype.hasOwnProperty.call(r,s)&&r[s]&&p.push(r[s][0]),r[s]=0;for(n in i)Object.prototype.hasOwnProperty.call(i,n)&&(t[n]=i[n]);u&&u(e);while(p.length)p.shift()();return o.push.apply(o,c||[]),a()}function a(){for(var t,e=0;e<o.length;e++){for(var a=o[e],n=!0,l=1;l<a.length;l++){var i=a[l];0!==r[i]&&(n=!1)}n&&(o.splice(e--,1),t=s(s.s=a[0]))}return t}var n={},r={app:0},o=[];function s(e){if(n[e])return n[e].exports;var a=n[e]={i:e,l:!1,exports:{}};return t[e].call(a.exports,a,a.exports,s),a.l=!0,a.exports}s.m=t,s.c=n,s.d=function(t,e,a){s.o(t,e)||Object.defineProperty(t,e,{enumerable:!0,get:a})},s.r=function(t){"undefined"!==typeof Symbol&&Symbol.toStringTag&&Object.defineProperty(t,Symbol.toStringTag,{value:"Module"}),Object.defineProperty(t,"__esModule",{value:!0})},s.t=function(t,e){if(1&e&&(t=s(t)),8&e)return t;if(4&e&&"object"===typeof t&&t&&t.__esModule)return t;var a=Object.create(null);if(s.r(a),Object.defineProperty(a,"default",{enumerable:!0,value:t}),2&e&&"string"!=typeof t)for(var n in t)s.d(a,n,function(e){return t[e]}.bind(null,n));return a},s.n=function(t){var e=t&&t.__esModule?function(){return t["default"]}:function(){return t};return s.d(e,"a",e),e},s.o=function(t,e){return Object.prototype.hasOwnProperty.call(t,e)},s.p="/";var l=window["webpackJsonp"]=window["webpackJsonp"]||[],i=l.push.bind(l);l.push=e,l=l.slice();for(var c=0;c<l.length;c++)e(l[c]);var u=i;o.push([0,"chunk-vendors"]),a()})({0:function(t,e,a){t.exports=a("56d7")},"56d7":function(t,e,a){"use strict";a.r(e);var n=a("2b0e"),r=function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("div",{attrs:{id:"app"}},[a("navbar"),a("router-view")],1)},o=[],s=function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("nav",{staticClass:"navbar navbar-expand-lg navbar-light bg-light"},[a("router-link",{staticClass:"navbar-brand",attrs:{to:{name:"home"}}},[t._v("Keepr")]),t._m(0),a("div",{staticClass:"collapse navbar-collapse",attrs:{id:"navbarText"}},[a("ul",{staticClass:"navbar-nav mr-auto"},[a("li",{staticClass:"nav-item",class:{active:"home"==t.$route.name}},[a("router-link",{staticClass:"nav-link",attrs:{to:{name:"home"}}},[t._v("Home")])],1),t.$auth.isAuthenticated?a("li",{staticClass:"nav-item",class:{active:"dashboard"==t.$route.name}},[a("router-link",{staticClass:"nav-link",attrs:{to:{name:"dashboard"}}},[t._v("My-Dashboard")])],1):t._e()]),a("span",{staticClass:"navbar-text"},[t.$auth.isAuthenticated?a("button",{staticClass:"btn btn-danger",on:{click:t.logout}},[t._v("logout")]):a("button",{staticClass:"btn btn-success",on:{click:t.login}},[t._v(" Login ")])])])],1)},l=[function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("button",{staticClass:"navbar-toggler",attrs:{type:"button","data-toggle":"collapse","data-target":"#navbarText","aria-controls":"navbarText","aria-expanded":"false","aria-label":"Toggle navigation"}},[a("span",{staticClass:"navbar-toggler-icon"})])}],i=a("bc3a"),c=a.n(i);c.a.create({baseURL:"https://localhost:5001",withCredentials:!0});var u={name:"Navbar",methods:{async login(){await this.$auth.loginWithPopup(),this.$store.dispatch("setBearer",this.$auth.bearer),console.log("this.$auth.user: "),console.log(this.$auth.user)},async logout(){this.$store.dispatch("resetBearer"),await this.$auth.logout({returnTo:window.location.origin})}}},h=u,p=a("2877"),d=Object(p["a"])(h,s,l,!1,null,null,null),b=d.exports,v=a("335d"),f={name:"App",async beforeCreate(){await Object(v["c"])(),this.$store.dispatch("setBearer",this.$auth.bearer)},components:{Navbar:b}},m=f,g=(a("5c0b"),Object(p["a"])(m,r,o,!1,null,null,null)),_=g.exports,w=a("8c4f"),y=function(){var t=this,e=t.$createElement;t._self._c;return t._m(0)},C=[function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("div",{staticClass:"home"},[a("h1",[t._v("Welcome Home")])])}],$={name:"home",computed:{user(){return this.$store.state.user}},methods:{logout(){this.$store.dispatch("logout")}}},O=$,x=Object(p["a"])(O,y,C,!1,null,null,null),j=x.exports,k=function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("div",{staticClass:"dashboard"},[a("h1",[t._v("WELCOME TO THE DASHBOARD")]),t._v(" public "+t._s(t.publicKeeps)+" user "+t._s(t.userKeeps)+" ")])},E=[],P={mounted(){},computed:{}},T=P,S=Object(p["a"])(T,k,E,!1,null,null,null),B=S.exports;n["a"].use(w["a"]);var L=new w["a"]({routes:[{path:"/",name:"home",component:j},{path:"/dashboard",name:"dashboard",component:B,beforeEnter:v["b"]}]}),M=a("2f62");n["a"].use(M["a"]);let A=location.host.includes("localhost")?"https://localhost:5001/":"/",H=c.a.create({baseURL:A+"api/",timeout:3e3,withCredentials:!0});var K=new M["a"].Store({state:{publicKeeps:[]},mutations:{},actions:{setBearer({},t){H.defaults.headers.authorization=t},resetBearer(){H.defaults.headers.authorization=""}}});const R="calvinsaxon.us.auth0.com",U="https://manytomany.api",D="kmtgh6Ym30rQLuPSoL1cg08OQQCCwHjf";n["a"].use(v["a"],{domain:R,clientId:D,audience:U,onRedirectCallback:t=>{L.push(t&&t.targetUrl?t.targetUrl:window.location.pathname)}}),new n["a"]({router:L,store:K,render:function(t){return t(_)}}).$mount("#app")},"5c0b":function(t,e,a){"use strict";var n=a("9c0c"),r=a.n(n);r.a},"9c0c":function(t,e,a){}});