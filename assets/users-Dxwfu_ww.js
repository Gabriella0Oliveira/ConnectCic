import{c as s,B as t}from"./httpClient-CwG61txm.js";const n=async o=>{try{return await s(`${t}/auth/login`,{method:"POST",headers:{"Content-Type":"application/json"},body:JSON.stringify(o)})}catch(r){throw console.error("Erro ao autenticar usuário:",r),r}},c=async(o,r)=>{try{return await s(`${t}/users/students/${o}`,{headers:{Authorization:`Bearer ${r}`}})}catch(e){throw console.error("Erro ao buscar aluno:",e),e}},u=async o=>{try{return await s(`${t}/users/students`,{method:"POST",headers:{"Content-Type":"application/json"},body:JSON.stringify(o)})}catch(r){throw console.error("Erro ao usuario: ",r),r}},i=async(o,r)=>{try{return await s(`${t}/users/professors/${o}`,{headers:{Authorization:`Bearer ${r}`}})}catch(e){throw console.error("Erro ao buscar professor:",e),e}},h=async o=>{try{return await s(`${t}/users/professors`,{method:"POST",headers:{"Content-Type":"application/json"},body:JSON.stringify(o)})}catch(r){throw console.error("Erro ao usuario: ",r),r}};export{n as a,u as b,c,i as g,h as p};
