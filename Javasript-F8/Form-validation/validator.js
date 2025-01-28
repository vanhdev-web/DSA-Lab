function Validator(options){
    
    function getParent(element, selector){
        while(element.parentElement){
            if(element.parentElement.matches(selector)){
                return element.parentElement
            }
        }
    }
    let selectorRules = {}

    function Validate(inputElement,rule){
        let errorMessage
        let rules = selectorRules[rule.selector]
        for (let i = 0; i< rules.length; i++){
            switch(inputElement.type){
                case 'radio':
                case 'checkbox':
                    errorMessage = rules[i](formElement.querySelector(rule.selector + ':checked'))
                    break
                default:
                    errorMessage = rules[i](inputElement.value)
            }
             
            if (errorMessage){
                break
            }
        }
        let errorElement = getParent(inputElement,options.formGroupSelector).querySelector(options.errorElement)
        
        if (errorMessage){
            errorElement.innerHTML = errorMessage
            getParent(inputElement,options.formGroupSelector).classList.add('invalid')
        }
        else{
            errorElement.innerHTML = ""
            getParent(inputElement,options.formGroupSelector).classList.remove('invalid')
        } 
        return !errorMessage
    }

    let formElement = document.querySelector('#form-1')
    if ( formElement){

        formElement.onsubmit = function(e){
            e.preventDefault()

            var isFormValid = true
            options.rules.forEach((rule) => {
            let inputElement = formElement.querySelector(rule.selector)
            var isValid = Validate(inputElement,rule)
            if (!isValid){
                isFormValid = false
            }
            })
           

            if(isFormValid){
                if (typeof options.onSubmit === 'function'){
                    var enableInputs = formElement.querySelectorAll('[name]:not([disabled])')
                    var formValues = Array.from(enableInputs).reduce(function(values, input){
                    (values[input.name]= input.value )    
                        return   values
                    },{})
                    options.onSubmit(formValues)
                    
                }
            }
        }



        
        options.rules.forEach((rule) => {
            //Lưu lại các rules
            if(Array.isArray(selectorRules[rule.selector])){
                selectorRules[rule.selector].push(rule.test)
            }
            else{
                selectorRules[rule.selector]= [rule.test]
            }
            

            let inputElements = formElement.querySelectorAll(rule.selector)
            Array.from(inputElements).forEach(function(inputElement){
                inputElement.onblur = function (){
                    Validate(inputElement,rule)
                }
                inputElement.oninput = function (){
                    let errorElement = getParent(inputElement,options.formGroupSelector).querySelector('.form-message')
                    errorElement.innerHTML = ""
                    getParent(inputElement,options.formGroupSelector).classList.remove('invalid')
                }
            })
            
        });
        
        
    }
}

Validator.isRequired = function(selector){
    return {
        selector: selector,
        test : function(value){
            return value ? undefined : "Vui lòng nhập trường này"
        }
    }

}

Validator.isEmail = function(selector){
    let regex = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/
    return {
        selector: selector,
        test : function(value){
            return regex.test(value) ? undefined : "Trường này phải là email"
        }
    }
}

Validator.minLength = function(selector,min){
    return {
        selector: selector,
        test : function(value){
            return value.length >= min ? undefined : `Yêu cầu nhập tối thiểu ${min} ký tự`
        }
    }

}

Validator.isConfirmed = function(selector,password){
    return {
        selector: selector,
        test : function(value){
            return value === password() ? undefined : "Mật khẩu nhập vào không chính xác"
        }
    }

}