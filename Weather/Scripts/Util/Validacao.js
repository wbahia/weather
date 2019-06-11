
function Trim(strTexto) {
    if (strTexto == null)
        strTexto = "";

    return strTexto.replace(/^\s+|\s+$/g, "");
}


function validarEmail(campoEmail) {
    var expReg = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return expReg.test(String(campoEmail).toLowerCase());
}


function validarCPF(cpf) {
    if (cpf == null || cpf == undefined)
        return;

    cpf = cpf.replace("-", "");
    cpf = cpf.replace(/\./g, "");

    var numeros, digitos, soma, i, resultado, digitos_iguais;
    digitos_iguais = 1;

    if (cpf.length < 11)
        return false;
    for (i = 0; i < cpf.length - 1; i++)
        if (cpf.charAt(i) != cpf.charAt(i + 1)) {
            digitos_iguais = 0;
            break;
        }
    if (!digitos_iguais) {
        numeros = cpf.substring(0, 9);
        digitos = cpf.substring(9);
        soma = 0;
        for (i = 10; i > 1; i--)
            soma += numeros.charAt(10 - i) * i;
        resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
        if (resultado != digitos.charAt(0))
            return false;
        numeros = cpf.substring(0, 10);
        soma = 0;
        for (i = 11; i > 1; i--)
            soma += numeros.charAt(11 - i) * i;
        resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
        if (resultado != digitos.charAt(1))
            return false;
        return true;
    }
    else
        return false;
}


function obterErro(chave, erros) {
    for (i = 0; i < erros.length; i++) {
        var erro = erros[i];
        if (erro.Chave == chave)
            return erros[i];
    }
}

function validarFormatoCEP(strCEP, blnVazio) {

    var objER = /^[0-9]{2}[0-9]{3}-[0-9]{3}$/;

    strCEP = Trim(strCEP);
    if (strCEP.length > 0) {
        if (objER.test(strCEP))
            return true;
        else
            return false;
    }

    else
        return blnVazio;
}

function validarTamanhoCEP(strCEP) {
    if (strCEP.length < 8)
        return false;
    return true;
}

function validaCamposVaziosMap(camposMap, erros) {
    for (var [chave, valor] of camposMap) {
        validaCamposVaziosMap(valor, chave, erros);
    }
}

function validarNumeroNegativo(numero) {
    if (numero < 0)
        return false;
    return true;
}

function validarCampoVazio(campo, nomeCampo, erros) {

    if (campo == null || campo == undefined) {
        erros.push("Preencha o campo\"" + nomeCampo + "\"");
    }
    else {
        campo = campo.Trim();
        if (campo.length == 0)
            erros.push("Preencha o campo\"" + nomeCampo + "\"");
    }
}


function removerEspacoBranco(palavra) {
    if (palavra == undefined || palavra == null)
        return null;
    else {
        palavra = palavra.replace(/\s/g, '');
        return palavra;
    }
}

//Permite somente letras
function ValidateAlpha(evt) {
    var keyCode = (evt.which) ? evt.which : evt.keyCode
    if ((keyCode < 65 || keyCode > 90) && (keyCode < 97 || keyCode > 123) && keyCode != 32)

        return false;
    return true;
}

function ValidarNome(nome) {
    var expReg = /^[A-ZÀ-Ÿ][A-zÀ-ÿ']+\s([A-zÀ-ÿ']\s?)*[A-ZÀ-Ÿ][A-zÀ-ÿ']+$/;
    return expReg.test(nome);
}

//impede numeros e caracteres especiais
function SemNumeros(evt) {
    var keyCode = (evt.which) ? evt.which : evt.keyCode
    if ((keyCode < 65 || keyCode > 384) && keyCode != 32)
        return false;
    return true;
}

//Permite somente numeros
function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : evt.keyCode
    if (charCode != 46 && charCode > 31
        && (charCode < 48 || charCode > 57))
        return false;
    return true;
}
