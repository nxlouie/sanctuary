# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.shortcuts import render
from django.http import JsonResponse, HttpResponse
from django.views.decorators.csrf import csrf_exempt
from django.db import connection

@csrf_exempt
def log_choose_environment(request):
    if request.method != 'POST':
        return HttpResponse(status=404)
    json_data = json.loads(request.body)
    user_id = json_data['user_id']
    environment_id = json_data['environment_id']
    cur = connection.cursor()
    cursor.execute('INSERT INTO choices (user_id, environment_id) VALUES ' '(%s, %s);', (username, message))
    return JsonResponse()

@csrf_exempt
def log_purchase_environment(request):
    if request.method != 'POST':
        return HttpResponse(status=404)
    json_data = json.loads(request.body)
    user_id = json_data['user_id']
    environment_id = json_data['environment_id']
    cur = connection.cursor()
    cursor.execute('INSERT INTO purchases (user_id, environment_id) VALUES ' '(%s, %s);', (username, message))
    return JsonResponse()

def get_popular_environments(request):
    if request.method != 'GET':
        return HttpResponse(status=404)
    res = {}
    res['environments'] = ['forest', 'beach']
    return JsonResponse(res)


def get_personalized_environments(request):
    if request.method != 'GET':
        return HttpResponse(status=404)
    res = {}
    res['environments'] = ['personalized', 'nice']
    return JsonResponse(res)
# Create your views here.
